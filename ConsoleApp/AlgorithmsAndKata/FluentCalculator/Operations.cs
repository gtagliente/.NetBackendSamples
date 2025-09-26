
namespace Fluent;

public class Operations{
    public Values Zero => new Values(this,0);
    public Values One => new Values(this,1);
    public Values Two => new Values(this,2);
    public Values Three => new Values(this,3);
    public Values Four => new Values(this,4);
    public Values Five => new Values(this,5);
    public Values Six => new Values(this,6);
    public Values Seven => new Values(this,7);
    public Values Eight => new Values(this,8);
    public Values Nine => new Values(this,9);
    public Values Ten => new Values(this,10);

    public OperationType _operationType {get;}
    public Values _previousValue {get;}
    public Values _nextValue {get;set;}

    public Operations(Values previousValue, OperationType operationType){
        this._operationType = operationType;
        this._previousValue = previousValue;
        this._previousValue._nextOperation = this;
    }
}

public enum OperationType{
    Plus,
    Minus,
    Times,
    DividedBy
}