using TMPro;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject arch;
    [SerializeField] private GameObject cone;
    [SerializeField] private GameObject cylinder;
    [SerializeField] private GameObject icosphere;
    [SerializeField] private GameObject prism;
    [SerializeField] private GameObject torus;

    [SerializeField] private GameObject targetCube;
    [SerializeField] private GameObject targetArch;
    [SerializeField] private GameObject targetCone;
    [SerializeField] private GameObject targetCylinder;
    [SerializeField] private GameObject targetIcosphere;
    [SerializeField] private GameObject targetPrism;
    [SerializeField] private GameObject targetTorus;

    [SerializeField] private TextMeshPro scoreText;

    private float score;

    public void OnButtonA()
    {

    }

    public void OnButtonB()
    {

    }

    public void OnButtonC()
    {

    }

    private void Update()
    {
        var cubeDotForward = GetScoreOppositeAndOrthogonalDirections(cube.transform.forward, targetCube.transform.forward);
        var cubeDotRight = GetScoreOppositeAndOrthogonalDirections(cube.transform.right, targetCube.transform.right);
        var cubeDotUp = GetScoreOppositeAndOrthogonalDirections(cube.transform.up, targetCube.transform.up);
        var cubeScore = (cubeDotForward + cubeDotRight + cubeDotUp) / 3;

        var cylinderDotUp = GetScoreOppositeDirections(cylinder.transform.up, targetCylinder.transform.up);

        var archDotForward = GetScoreOppositeDirections(arch.transform.forward, targetArch.transform.forward);
        var archDotUp = GetScoreOnlyOneDirection(arch.transform.up, targetArch.transform.up);
        var archScore = (archDotForward + archDotUp) / 2;

        var coneDotUp = GetScoreOnlyOneDirection(cone.transform.up, targetCone.transform.up);

        var torusDotUp = GetScoreOppositeDirections(torus.transform.up, targetTorus.transform.up);

        var prismDotForward = GetScoreOppositeDirections(prism.transform.forward, targetPrism.transform.forward);
        var prismDotUp = GetScoreOnlyOneDirection(prism.transform.up, targetPrism.transform.up);
        var prismScore = (prismDotForward + prismDotUp) / 2;

        scoreText.text = string.Format("cube: {0}\n" +
                                       "cylinder: {1}\n" +
                                       "arch: {2}\n" +
                                       "cone: {3}\n" +
                                       "torus: {4}\n" +
                                       "prism: {5}",
                                       cubeScore,
                                       cylinderDotUp,
                                       archScore,
                                       coneDotUp,
                                       torusDotUp,
                                       prismScore);
    }

    private float GetScoreOnlyOneDirection(Vector3 v1, Vector3 v2)
    {
        return 1 - ((Mathf.Acos(Vector3.Dot(v1, v2)) * (180 / Mathf.PI)) / 90) / 2;
    }

    private float GetScoreOppositeDirections(Vector3 v1, Vector3 v2)
    {
        return (90 - Mathf.Acos(Mathf.Abs(Vector3.Dot(v1, v2))) * (180 / Mathf.PI)) / 90;
    }

    private float GetScoreOppositeAndOrthogonalDirections(Vector3 v1, Vector3 v2)
    {
        return Mathf.Abs(((Mathf.Acos(Mathf.Abs(Vector3.Dot(v1, v2))) * (180 / Mathf.PI)) / 90) - 0.5f) * 2;
    }
}
