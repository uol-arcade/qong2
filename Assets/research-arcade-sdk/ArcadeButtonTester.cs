using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using ResearchArcade;

[System.Serializable]
public class PlayerButtonUIMapping
{
    public RawImage A;
    public RawImage B;
    public RawImage C;
    public RawImage D;
    public RawImage E;
    public RawImage F;

    public RawImage Up;
    public RawImage Down;
    public RawImage Left;
    public RawImage Right;

    public RawImage Start;
}

public class ArcadeButtonTester : MonoBehaviour
{
    public PlayerButtonUIMapping player1;
    public PlayerButtonUIMapping player2;

    public RawImage quitButtonImage;

    public Color activeColor = Color.yellow;
    public Color inactiveColor = Color.gray;

    private List<System.Func<(bool status, RawImage image)>> player1CheckFuncs;
    private List<System.Func<(bool status, RawImage image)>> player2CheckFuncs;
    private List<System.Func<(bool status, RawImage image)>> globalCheckFuncs;

    private float exitHoldTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player1CheckFuncs = new List<System.Func<(bool status, RawImage image)>>
        {
            () => (ArcadeInput.Player1.A.HeldDown, player1.A),
            () => (ArcadeInput.Player1.B.HeldDown, player1.B),
            () => (ArcadeInput.Player1.C.HeldDown, player1.C),
            () => (ArcadeInput.Player1.D.HeldDown, player1.D),
            () => (ArcadeInput.Player1.E.HeldDown, player1.E),
            () => (ArcadeInput.Player1.F.HeldDown, player1.F),
            () => (ArcadeInput.Player1.JoyUp.HeldDown, player1.Up),
            () => (ArcadeInput.Player1.JoyDown.HeldDown, player1.Down),
            () => (ArcadeInput.Player1.JoyLeft.HeldDown, player1.Left),
            () => (ArcadeInput.Player1.JoyRight.HeldDown, player1.Right),
            () => (ArcadeInput.Player1.Start.HeldDown, player1.Start)
        };

        player2CheckFuncs = new List<System.Func<(bool status, RawImage image)>>
        {
            () => (ArcadeInput.Player2.A.HeldDown, player2.A),
            () => (ArcadeInput.Player2.B.HeldDown, player2.B),
            () => (ArcadeInput.Player2.C.HeldDown, player2.C),
            () => (ArcadeInput.Player2.D.HeldDown, player2.D),
            () => (ArcadeInput.Player2.E.HeldDown, player2.E),
            () => (ArcadeInput.Player2.F.HeldDown, player2.F),
            () => (ArcadeInput.Player2.JoyUp.HeldDown, player2.Up),
            () => (ArcadeInput.Player2.JoyDown.HeldDown, player2.Down),
            () => (ArcadeInput.Player2.JoyLeft.HeldDown, player2.Left),
            () => (ArcadeInput.Player2.JoyRight.HeldDown, player2.Right),
            () => (ArcadeInput.Player2.Start.HeldDown, player2.Start)
        };

        globalCheckFuncs = new List<System.Func<(bool status, RawImage image)>>
        {
            () => (ArcadeInput.Exit.HeldDown, quitButtonImage)
            //..
        };
    }


    // Update is called once per frame
    void Update()
    {
        if(ArcadeInput.Exit.HeldDown)
            exitHoldTime += Time.deltaTime;

        if(ArcadeInput.Exit.Up)
            exitHoldTime = 0f;

        if(exitHoldTime >= 5f)
        {
            exitHoldTime = -9001f;
            ResearchArcade.Navigation.ExitGame();
        }



        foreach (var checkFunc in player1CheckFuncs)
        {
            var returnValue = checkFunc();
            returnValue.image.color = (returnValue.status) ? (activeColor) : (inactiveColor);
        }

        foreach (var checkFunc in player2CheckFuncs)
        {
            var returnValue = checkFunc();
            returnValue.image.color = (returnValue.status) ? (activeColor) : (inactiveColor);
        }

        foreach (var checkFunc in globalCheckFuncs)
        {
            var returnValue = checkFunc();
            returnValue.image.color = (returnValue.status) ? (activeColor) : (inactiveColor);
        }
    }
}