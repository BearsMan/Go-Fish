using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

	public enum CardFaceType
	{
		Invalid = -1,

		Ace,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King
	}

	public enum CardSuitType
	{
		Invalid = -1,

		Clubs,
		Diamonds,
		Hearts,
		Spades
	}

	public Texture2D CardFaceImage = null;
	public Texture2D CardBackImage = null;
	public CardFaceType CardType = CardFaceType.Invalid;
	public CardSuitType CardSuit = CardSuitType.Invalid;

	public Texture2D DisplayImage
	{
		set
		{
			Sprite Image = Sprite.Create(value, new Rect(0.0f, 0.0f, value.width, value.height), new Vector2(0.5f, 0.5f), 100.0f);
			Image Display = gameObject.GetComponent<Image>();
			Display.sprite = Image;


		}
	}
	public Texture2D Face
	{
		set
		{
			CardFaceImage = value;
		}
		get
		{
			return CardFaceImage;
		}
	}

	public Texture2D Back
	{
		set
		{
			CardBackImage = value;
		}
		get
		{
			return CardBackImage;
		}
	}

	public CardFaceType Type
	{
		set
		{
			CardType = value;
		}
		get
		{
			return CardType;
		}
	}

	public CardSuitType Suit
	{
		set
		{
			CardSuit = value;
		}
		get
		{
			return CardSuit;
		}
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
