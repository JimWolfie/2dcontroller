using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "speaking",menuName = "speakingContainer", order =3)]
public class TextContainerPerLevel : ScriptableObject
{
	public List<string> Story;
	public string EntryText;
	public string ExitText;
	public int storyIndex;
	public bool noStoryLeft = false;
	
	public void IncrementStory(){
		storyIndex +=1;
		if(Story.Count<=storyIndex){
			storyIndex = 0;
			noStoryLeft=true;
		}
	}
	
}
