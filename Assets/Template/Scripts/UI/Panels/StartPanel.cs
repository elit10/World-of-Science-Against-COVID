using UnityEngine.UI;
public class StartPanel : UIPanel
{

	public Text levelText;



	private void OnEnable()
	{
		levelText.text = "Level " + LevelManager.instance.curLevel;
	}

	public void OnPressPlay()
	{
		LevelManager.instance.StartLevel();
		this.Fade(false, 1);
	}
}