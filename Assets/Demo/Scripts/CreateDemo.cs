using UnityEngine;
using DG.Tweening;
using AngryKoala.PoseFormer;

public class CreateDemo : MonoBehaviour
{
    [SerializeField] private Transform visual;

    [SerializeField] private Character characterPrefab;

    public void CreatePoseForm()
    {
        PoseForm poseForm = PoseFormer.Create(visual, false);

        Character character = Instantiate(characterPrefab, visual.position, visual.rotation);

        PoseFormer.Apply(character.Visual, poseForm);
        character.Visual.position = visual.position;

        character.Visual.localScale = Vector3.zero;
        character.Visual.DOScale(1f, .3f).SetEase(Ease.OutBack).SetDelay(.2f);
    }
}
