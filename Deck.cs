using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public GameObject CardPrefab = null;
	List<GameObject> Cards = null;

	public List<GameObject> GameDeck
	{
		get
		{
			return Cards;
		}
	}
	void Start()
	{
		Cards = new List<GameObject>();
		Texture2D BackImage = Resources.Load<Texture2D>("CardBack");

		//Hearts
		for (int i = 0; i < 13; i++)
		{
			GameObject NewCardGameObject = GameObject.Instantiate<GameObject>(CardPrefab, gameObject.transform);
			if (NewCardGameObject)
			{
				Card NewCard = NewCardGameObject.GetComponent<Card>();

				NewCard.Back = BackImage;
				string CardName = "Heart" + (i + 1).ToString("D2");
				NewCard.Face = Resources.Load<Texture2D>(CardName);
				NewCard.CardType = (Card.CardFaceType)i;
				NewCard.CardSuit = Card.CardSuitType.Hearts;
				Cards.Add(NewCardGameObject);
			}
		}

		//Diamonds
		for (int i = 0; i < 13; i++)
		{
			GameObject NewCardGameObject = GameObject.Instantiate<GameObject>(CardPrefab, gameObject.transform);
			if (NewCardGameObject)
			{
				Card NewCard = NewCardGameObject.GetComponent<Card>();

				NewCard.Back = BackImage;
				string CardName = "Diamond" + (i + 1).ToString("D2");
				NewCard.Face = Resources.Load<Texture2D>(CardName);
				NewCard.CardType = (Card.CardFaceType)i;
				NewCard.CardSuit = Card.CardSuitType.Diamonds;
				Cards.Add(NewCardGameObject);
			}
		}

		//Clubs
		for (int i = 0; i < 13; i++)
		{
			GameObject NewCardGameObject = GameObject.Instantiate<GameObject>(CardPrefab, gameObject.transform);
			if (NewCardGameObject)
			{
				Card NewCard = NewCardGameObject.GetComponent<Card>();

				NewCard.Back = BackImage;
				string CardName = "Club" + (i + 1).ToString("D2");
				NewCard.Face = Resources.Load<Texture2D>(CardName);
				NewCard.CardType = (Card.CardFaceType)i;
				NewCard.CardSuit = Card.CardSuitType.Clubs;
				Cards.Add(NewCardGameObject);
			}

		}

		//Spades
		for (int i = 0; i < 13; i++)
		{
			GameObject NewCardGameObject = GameObject.Instantiate<GameObject>(CardPrefab, gameObject.transform);
			if (NewCardGameObject)
			{
				Card NewCard = NewCardGameObject.GetComponent<Card>();

				NewCard.Back = BackImage;
				string CardName = "Spade" + (i + 1).ToString("D2");
				NewCard.Face = Resources.Load<Texture2D>(CardName);
				NewCard.CardType = (Card.CardFaceType)i;
				NewCard.CardSuit = Card.CardSuitType.Spades;
				Cards.Add(NewCardGameObject);
			}
		}
	}
}
