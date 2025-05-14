using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardScript : MonoBehaviour
{
    [Header("UI")]
    public Text numCardsText;
    public RectTransform handPlace;
    public RectTransform deckPlace;
    public RectTransform discardPlace;

    [Header("Card Prefabs")]
    public GameObject[] cardPrefabs;          // 0:Deck 1:Discard 2+:Card Types
    public GameObject[] cardAbilitiesPrefabs;

    [Header("Gameplay References")]
    public Camera cam;
    public Camera camera;
    public GameObject player;
    public GameObject ricochetBullet;
    public GameObject iceBullet;
    public playerAttack atk;

    private List<Card> _deck = new List<Card>();
    private List<Card> _discard = new List<Card>();
    private List<Card> _hand = new List<Card>();

    private void Awake()
    {
        // Initialize deck
        _deck.Add(new Card("Bomb", "PlaceObj", false, false, cardPrefabs[0], cardAbilitiesPrefabs[0]));
        _deck.Add(new Card("SpinLasar", "OnPersonThenGo", false, false, cardPrefabs[1], cardAbilitiesPrefabs[1]));
        _deck.Add(new Card("C", "Consumable", false, false, cardPrefabs[2]));
        _deck.Add(new Card("D", "Melee", false, false, cardPrefabs[3]));
        _deck.Add(new Card("E", "Ranged", false, false, cardPrefabs[4]));
        _deck.Add(new Card("IceBullet", "Bullet Replacer", false, false, cardPrefabs[5], iceBullet, 10f));
        _deck.Add(new Card("Ricochet Bullet", "Bullet Replacer", false, false, cardPrefabs[6], ricochetBullet, 5f));
        _deck.Add(new Card("Teleport", "Teleport", false, false, cardPrefabs[7]));

        numCardsText.text = _deck.Count.ToString();
        Draw();
    }

    private void Update()
    {
        numCardsText.text = _deck.Count.ToString();
        checkActive();


        if (whatIsActive() >= 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            playCard(whatIsActive());
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.GetComponent<playerAttack>().Shoot();
        }
    }

    public void Draw()
    {
        if (_hand.Count == 0)
        {
            if (_deck.Count < 3) deckEmpty();
            StartCoroutine(waitAndDraw());
            updateCardsShown();
        }
    }

    public void discardCard(int index)
    {
        if (index < 0 || index >= _hand.Count) return;

        _discard.Add(_hand[index]);
        _hand.RemoveAt(index);

        if (_hand.Count == 0) Draw();

        updateCardsShown();
    }

    public void addCard(Card card)
    {
        _deck.Add(card);
    }

    public bool checkHandEmpty() => _hand.Count == 0;

    public void resetActivity()
    {
        var indicator = GetComponent<indicateSelectedCard>();
        for (int i = 0; i < _hand.Count; i++)
        {
            if (_hand[i].GetActiveStatus())
            {
                indicator.goBackDown(i, _hand[i]);
                _hand[i].SetActiveStatus(false);
            }
        }
    }

    public int checkActive()
    {
        var indicator = GetComponent<indicateSelectedCard>();

        for (int i = 0; i < _hand.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                if (_hand[i].GetActiveStatus())
                {
                    indicator.goBackDown(i, _hand[i]);
                    _hand[i].SetActiveStatus(false);
                }
                else
                {
                    resetActivity();
                    _hand[i].SetActiveStatus(true);
                    indicator.indicate(i, _hand[i]);
                }
                return i + 1;
            }
        }
        return -1;
    }

    public void playCard(int index)
    {
        if (index >= _hand.Count) return;

        Card card = _hand[index];
        //Debug.Log("Playing card: " + card.ToString());

        discardCard(index);

        switch (card.getType())
        {
            case "Bullet Replacer":
                playBulletReplacer(card);
                break;
            case "Teleport":
                playTeleport(card);
                break;
            case "PlaceObj":
                Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(card.GetAbilityObject(), mousePos, Quaternion.identity);
                break;
            case "OnPersonThenGo":
                Debug.Log("lasar gets called");
                playOnPersonThenGo(card, cam.ScreenToWorldPoint(Input.mousePosition));
                break;
        }
    }

    public void playBulletReplacer(Card card)
    {
        if (card.GetAbilityObject() != null)
        {
            var attack = player.GetComponent<playerAttack>();
            GameObject originalBullet = attack.getBulletType();
            StartCoroutine(ReplaceBullet(attack, originalBullet, card.GetAbilityObject(), card.getLifespan()));
        }
    }

    public void playTeleport(Card card)
    {
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        player.transform.position = mousePos;
    }

    public void playOnPersonThenGo(Card card, Vector3 goTo){
        Instantiate(card.GetAbilityObject(),player.transform.position, Quaternion.identity);
        Debug.Log(goTo.ToString() + "to here");
        card.GetAbilityObject().GetComponent<spinLasar>().moveTo(goTo);

    }

    public int whatIsActive()
    {
        for (int i = 0; i < _hand.Count; i++)
        {
            if (_hand[i].GetActiveStatus()) return i;
        }
        return -1;
    }

    public void deckEmpty()
    {
        _deck.AddRange(_discard);
        _discard.Clear();
        reshuffle(_deck);
        updateCardsShown();
    }

    private void reshuffle(List<Card> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int rand = Random.Range(i, deck.Count);
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
    }

    public void updateCardsShown()
{
    foreach (Transform child in handPlace) Destroy(child.gameObject);
    foreach (Transform child in discardPlace) Destroy(child.gameObject);

    for (int i = 0; i < _hand.Count; i++)
    {
        GameObject cardUI = Instantiate(_hand[i].GetGameObject(), handPlace);

    }

    if (_discard.Count > 0)
    {
        Instantiate(_discard[^1].GetGameObject(), discardPlace);
    }
}

    public List<Card> getHand() => _hand;

    private IEnumerator<WaitForSeconds> ReplaceBullet(playerAttack attack, GameObject originalBullet, GameObject newBullet, float duration)
    {
        attack.setBulletType(newBullet);
        yield return new WaitForSeconds(duration);
        attack.setBulletType(originalBullet);
    }

    private IEnumerator<WaitForSeconds> waitAndDraw()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 3 && _deck.Count > 0; i++)
        {
            Card card = _deck[0];
            _deck.RemoveAt(0);
            card.SetActiveStatus(false);
            _hand.Add(card);
            yield return new WaitForSeconds(0.2f);
            updateCardsShown();
        }
    }
}
