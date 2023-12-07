using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Play : MonoBehaviour
{
	public enum PlayerNumber
	{
		Invalid = -1,

		One,
		Two
	}

	[SerializeField] private GameObject DeckObject = null;

	private List<GameObject> PlayerOneCards = null;
	private List<GameObject> PlayerTwoCards = null;
	private List<GameObject> GameDeck = null;

	private PlayerNumber CurrentPlayer = PlayerNumber.Invalid;
	private Card.CardFaceType PlayerGuess = Card.CardFaceType.Invalid;

	private int PlayerOneHands = 0;
	private int PlayerTwoHands = 0;

	private string Feedback = null;

	//Add code below this line
	void Start()
	{
		CurrentPlayer = PlayerNumber.One;
		PlayerOneCards = new List<GameObject>();
		PlayerTwoCards = new List<GameObject>();
		Deck deckClass = DeckObject.GetComponent<Deck>();
		GameDeck = deckClass.GameDeck;
		Deal();
	}
    void Update()
    {
		PlayerGuess = UiController.GetInstance().Guess;
		if (PlayerGuess != Card.CardFaceType.Invalid)
		{
			UiController.GetInstance().Reset();
			CheckForMatch();
		}
    }
	public void CheckForMatch()
	{
		bool switchPlayers = false;
	}
    private void Deal()
	{
		for (int i = 0; i < 7; i++)
		{
			int cardIndex = -1;
			cardIndex = Random.Range(0, GameDeck.Count);
			GameObject playerCard = GameDeck[cardIndex];
			PlayerOneCards.Add(playerCard);
			GameDeck.RemoveAt(cardIndex);
			PlayerTwoCards.Add(playerCard);
			cardIndex = Random.Range(0, GameDeck.Count);
			GameObject opponentCard = GameDeck[cardIndex];
			PlayerTwoCards.Add(opponentCard);
			GameDeck.RemoveAt(cardIndex);
		}
		UpdateGui();



		//Add code above this line
		void UpdateGui()
		{
			UiController.GetInstance().UpdateGui(PlayerOneCards, PlayerTwoCards, CurrentPlayer, PlayerOneHands, PlayerTwoHands);
		}
		GameObject Draw()
		{
			GameObject PlayerCard = null;
			int CardIndex = -1;

			if (GameDeck.Count > 0)
			{
				CardIndex = Random.Range(0, GameDeck.Count);
				PlayerCard = GameDeck[CardIndex];
				switch (CurrentPlayer)
				{
					case PlayerNumber.One:
						PlayerOneCards.Add(PlayerCard);
						break;
					case PlayerNumber.Two:
						PlayerTwoCards.Add(PlayerCard);
						break;
				}

				GameDeck.RemoveAt(CardIndex);
				UpdateGui();
			}
			return PlayerCard;
		}

		void CheckForHands(List<GameObject> Hand)
		{
			int Points = 0;
			int[] Cards = new int[13];
			int CardIndex;
			List<GameObject> Discards = new List<GameObject>();

			//Count each type of card in hand
			foreach (GameObject g in Hand)
			{
				if (g.activeInHierarchy == true)
				{
					Card CardClass = g.GetComponent<Card>();
					CardIndex = (int)CardClass.CardType;
					Cards[CardIndex]++;
				}
			}

			//Search for counts of 4
			for (int i = 0; i < Cards.Length; i++)
			{
				int Count = Cards[i];
				if (Count >= 4)
				{
					Points++;
					//Remove all of the cards with the matching type from the hand
					Card.CardFaceType CardType = (Card.CardFaceType)i;
					Feedback += "Removed a hand of " + CardType + ". ";
					foreach (GameObject g in Hand)
					{
						Card CardClass = g.GetComponent<Card>();
						if (CardClass.CardType == CardType)
						{
							Discards.Add(g);
						}
					}
				}
			}

			foreach (GameObject d in Discards)
			{
				d.SetActive(false);
				Hand.Remove(d);
			}
			Discards.Clear();
			UiController.GetInstance().Feedback = Feedback;
			Feedback = null;

			switch (CurrentPlayer)
			{
				case PlayerNumber.One:
					{
						PlayerOneHands += Points;
					}
					break;
				case PlayerNumber.Two:
					{
						PlayerTwoHands += Points;
					}
					break;
			}
			UpdateGui();
		}

	}
}
