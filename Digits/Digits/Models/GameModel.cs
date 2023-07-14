
using System;

namespace Digits.Models;

record GameModel(int TagertValue, GameNumber[] Values)
{
    public static GameModel Level1 { get; } = new GameModel(58, new GameNumber[]
    {
        new GameNumber(1,new NumberPosition(0,0),2),
        new GameNumber(2,new NumberPosition(0,1),7),
        new GameNumber(3,new NumberPosition(0,2),9),
        new GameNumber(4,new NumberPosition(1,0),10),
        new GameNumber(5,new NumberPosition(1,1),11),
        new GameNumber(6,new NumberPosition(1,2),25),
    });
}
record NumberPosition(int Row,int Col);
record GameNumber(int Id,NumberPosition Position,int Value);
public enum Operation
{
    Cong,
    Tru,
    Nhan,
    Chia
}

record OperationItem(GameNumber One,GameNumber Two,Operation Operation)
{
    internal int CalcValue()
    {
        return Operation switch
        {
            Operation.Cong => One.Value + Two.Value,
            Operation.Tru => One.Value - Two.Value,
            Operation.Nhan => One.Value * Two.Value,
            Operation.Chia => One.Value / Two.Value,
            _ => throw new NotImplementedException(),
        };
    }

    public bool IsValid()
    {
        return Operation switch
        {
            Operation.Nhan => One.Value >= Two.Value,
            Operation.Chia => One.Value % Two.Value == 0,
            _ => true,
        };
    }
}