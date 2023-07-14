﻿using Digits.Models;
using MauiReactor;
using System.Linq;
using System;
using MauiReactor.Canvas;
using MauiReactor.Animations;

namespace Digits.Pages.Components;
class GameBoardState
{
    public Operation? CurrentOperation { get; set; }
    public GameNumber CurrentNumber { get; set; }
    public OperationItem OperationInError { get; set; }
}
class GameBoard : Component<GameBoardState>
{
    private GameNumber[] _gameNumbers;
    private int _target;
    private Action<OperationItem> _newOperationAction;
    private Action _undoOperationAction;

    public GameBoard Target(int target)
    {
        _target = target;
        return this;
    }

    public GameBoard Board(GameNumber[] gameNumbers)
    {
        _gameNumbers = gameNumbers;
        return this;
    }

    public GameBoard OnNewOperation(Action<OperationItem> action)
    {
        _newOperationAction = action;
        return this;
    }

    public GameBoard OnUndoOperation(Action action)
    {
        _undoOperationAction = action;
        return this;
    }
    public override VisualNode Render()
    {
        var mainState = GetParameter<MainState>();
        return new CanvasView
        {
          new Column("100,*,100")
          {
              new Text($"{_target}")
              .VerticalAlignment(VerticalAlignment.Center)
              .HorizontalAlignment(HorizontalAlignment.Center)
              .FontSize(46)
              .FontWeight(800),
              new Align
              {
                  new Group
                  {
                      _gameNumbers?.Select(RenderBoardNumberButton).ToArray()
                  }
              }
              .VCenter()
              .HCenter()
              .Width(300)
              .Height(200),
              new Row
              {
                  RenderUndoButton(),
                  Enum.GetValues<Operation>().Select(RenderOperationButton).ToArray()
              }
              ,
              new Timer(0, 1000, () => SetState(s =>
              {
                  s.OperationInError =null;
              }))
              .IsEnabled(State.OperationInError!=null)
          }
        }.HeightRequest(400)
        .WidthRequest(300)
        .BackgroundColor(Colors.Transparent)
        .IsVisible(mainState.Value.PageView == PageView.GameBoard);
    }
    VisualNode RenderUndoButton()
    {
        return new PointInteractionHandler
        {
            new Align
            {
                new Picture($"Digits.Resources.Images.undo_icon_green.png")
            }
            .Margin(5,0)
        }
        .OnTap(_undoOperationAction);
    }
    VisualNode RenderOperationButton(Operation operation)
    {
        return new AnimatingButton
        {
            new GameBoardOperationButton()
                .Operation(operation)
                .IsSelected(State.CurrentOperation == operation || State.OperationInError?.Operation == operation)
                .OnClick(() => OnOperationSelected(operation))
         }.InError(State.OperationInError?.Operation == operation);
    }

    private void OnOperationSelected(Operation operation)
    {
        if (State.CurrentNumber != null)
        {
            SetState(s => s.CurrentOperation = operation);
        }
    }

    VisualNode RenderBoardNumberButton(GameNumber number)
    {
        return new AnimatingButton
        {

            new GameBoardNumberButton()
            .Number(number)
            .IsSelected(State.CurrentNumber == number || State.OperationInError?.One == number || State.OperationInError.Two == number)
            .OnClick(() => OnNumberClicked(number))
        }.InError(State.OperationInError?.One == number || State.OperationInError.Two == number)
        ;

    }

    private void OnNumberClicked(GameNumber number)
    {
        if (State.CurrentOperation == null)
        {
            SetState(s => s.CurrentNumber = s.CurrentNumber == number ? null : number);
        }
        else if (State.CurrentNumber != null)
        {
            var newOperation = new OperationItem(State.CurrentNumber, number, State.CurrentOperation.Value);

            if (!newOperation.IsValid())
            {
                SetState(s =>
                {
                    s.CurrentNumber = null;
                    s.CurrentOperation = null;
                    s.OperationInError = newOperation;
                });
            }
            else
            {
                SetState(s =>
                {
                    s.CurrentNumber = null;
                    s.CurrentOperation = null;
                });

                _newOperationAction?.Invoke(newOperation);
            }
        }
    }
}


