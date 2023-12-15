using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UiController : MonoBehaviour
{

	private static UiController Instance = null;

    [System.Obsolete]
    public static UiController GetInstance()
	{
		if (Instance == null)
		{
			UiController Controller = FindObjectOfType<UiController>();
			if (Controller != null)
			{
				Instance = Controller;
			}
			else
			{
				GameObject g = new GameObject();
				g.name = "UiController";
				Instance = g.AddComponent<UiController>();
			}
			Instance.Init();
		}
		return Instance;
	}

	[Tooltip("This image indicates that it is player one's turn.")]
	[SerializeField] GameObject PlayerOneTurnMarker;

	[Tooltip("This image indicates that it is player two's turn.")]
	[SerializeField] GameObject PlayerTwoTurnMarker;

	[Tooltip("This text object displays the number hands won by player 1.")]
	[SerializeField] TMP_Text PlayerOneHandsText;

	[Tooltip("This text object displays the number hands won by player 2.")]
	[SerializeField] TMP_Text PlayerTwoHandsText;

	[Tooltip("This text object provides feedback to the player.")]
	[SerializeField] TMP_Text FeedbackText;

	[Tooltip("This panel will display the cards for player one.")]
	[SerializeField] private GameObject PlayerOnePanel = null;

	[Tooltip("This panel will display the cards for player two.")]
	[SerializeField] private GameObject PlayerTwoPanel = null;

	[Tooltip("This input object captures the current player's guess.")]
	[SerializeField] private TMP_InputField PlayerGuessInput = null;

	private Card.CardFaceType PlayerGuess = Card.CardFaceType.Invalid;
	private Play.PlayerNumber CurrentPlayer = Play.PlayerNumber.Invalid;
	private List<GameObject> PlayerOneCards = null;
	private List<GameObject> PlayerTwoCards = null;

	public Card.CardFaceType Guess
	{
		get
		{
			return PlayerGuess;
		}
	}

	public string Feedback
	{
		set
		{
			FeedbackText.text = value;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		Init();
	}

	private void Init()
	{
		DontDestroyOnLoad(Instance);
		Reset();
	}

	public void Reset()
	{
		PlayerGuess = Card.CardFaceType.Invalid;
		PlayerGuessInput.text = null;
	}

	public void UpdateGui(List<GameObject> PlayerOneCards, List<GameObject> PlayerTwoCards, Play.PlayerNumber Player, int PlayerOneHands, int PlayerTwoHands)
	{
		CurrentPlayer = Player;

		this.PlayerOneCards = PlayerOneCards;
		this.PlayerTwoCards = PlayerTwoCards;
		DisplayCards(false);
		switch (Player)
		{
			case Play.PlayerNumber.One:
				PlayerOneTurnMarker.SetActive(true);
				PlayerTwoTurnMarker.SetActive(false);
				break;
			case Play.PlayerNumber.Two:
				PlayerTwoTurnMarker.SetActive(true);
				PlayerOneTurnMarker.SetActive(false);
				break;
		}
		PlayerOneHandsText.text = PlayerOneHands.ToString();
		PlayerTwoHandsText.text = PlayerTwoHands.ToString();
	}

	private void DisplayCards(bool RevealActive, bool RevealAll = false)
	{
		foreach (GameObject g in PlayerOneCards)
		{
			Card CardClass = g.GetComponent<Card>();
			Texture2D Back = CardClass.Back;
			Texture2D Face = CardClass.Face;
			if ((CurrentPlayer == Play.PlayerNumber.One && RevealActive) || RevealAll)
			{
				CardClass.DisplayImage = Face;
			}
			else
			{
				CardClass.DisplayImage = Back;
			}
			g.transform.parent = PlayerOnePanel.transform;
		}

		foreach (GameObject g in PlayerTwoCards)
		{
			Card CardClass = g.GetComponent<Card>();
			Texture2D Back = CardClass.Back;
			Texture2D Face = CardClass.Face;
			if ((CurrentPlayer == Play.PlayerNumber.Two && RevealActive) || RevealAll)
			{
				CardClass.DisplayImage = Face;
			}
			else
			{
				CardClass.DisplayImage = Back;

			}
			g.transform.parent = PlayerTwoPanel.transform;
		}
	}

	public void ProcessGuess()
	{
		string PlayerGuessText = PlayerGuessInput.text;

		Card.CardFaceType GuessCard = Card.CardFaceType.Invalid;

		switch (PlayerGuessText.ToLower())
		{
			case "a":
				{
					GuessCard = Card.CardFaceType.Ace;
				}
				break;
			case "2":
				{
					GuessCard = Card.CardFaceType.Two;
				}
				break;
			case "3":
				{
					GuessCard = Card.CardFaceType.Three;
				}
				break;
			case "4":
				{
					GuessCard = Card.CardFaceType.Four;
				}
				break;
			case "5":
				{
					GuessCard = Card.CardFaceType.Five;
				}
				break;
			case "6":
				{
					GuessCard = Card.CardFaceType.Six;
				}
				break;
			case "7":
				{
					GuessCard = Card.CardFaceType.Seven;
				}
				break;
			case "8":
				{
					GuessCard = Card.CardFaceType.Eight;
				}
				break;
			case "9":
				{
					GuessCard = Card.CardFaceType.Nine;
				}
				break;
			case "t":
				{
					GuessCard = Card.CardFaceType.Ten;
				}
				break;
			case "j":
				{
					GuessCard = Card.CardFaceType.Jack;
				}
				break;
			case "q":
				{
					GuessCard = Card.CardFaceType.Queen;
				}
				break;
			case "k":
				{
					GuessCard = Card.CardFaceType.King;
				}
				break;
			default:
				{
					Feedback = "\"" + PlayerGuessText + "\" is an invalid card!";
					PlayerGuessInput.text = null;
				}
				break;
		}

		if (GuessCard != Card.CardFaceType.Invalid)
		{
			PlayerGuess = GuessCard;
		}
	}

	void Update()
	{
	}

	public void OnGuessClicked()
	{
		ProcessGuess();
	}

	public void OnRevealCardsClicked()
	{
		DisplayCards(true);
	}
}
