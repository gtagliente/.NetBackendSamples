
namespace Fluent;

public class Values{
    
    public Operations? Plus => new Operations(this,OperationType.Plus);
    public Operations? Minus => new Operations(this,OperationType.Minus);
    public Operations? Times => new Operations(this,OperationType.Times);
    public Operations? DividedBy => new Operations(this,OperationType.DividedBy);

    protected double _value {get; set;}
    public OperationType operationType {get;}
    public Operations? _previousOperation {get; set; } 
    public Operations? _nextOperation {get; set;} 
    
    public Values(Operations? previousOperation,double value)
    {
        this._value = value;
        this._previousOperation = previousOperation;
        if(_previousOperation!=null)
            this._previousOperation._nextValue = this;
    }

    public double Result(){
        return Values.Calculate(this);
    }

    public static implicit operator double(Values v) {
        return Values.Calculate(v);
    }

    public static double Calculate(Values v){
                // Console.WriteLine("Current value operator: " + v._value);

        Values firstValue = v;
        while(firstValue._previousOperation!=null){
            firstValue = firstValue._previousOperation._previousValue;
        }
        Values next = firstValue;
        double result = firstValue._value;
        while(next._nextOperation!=null && next._nextOperation._nextValue!=null){
            switch(next._nextOperation._operationType){
                case OperationType.Times:
                {
                    Values timesValue = new Values(next?._previousOperation, next._value);
                    timesValue._value = next._value *  next._nextOperation._nextValue._value;
                    timesValue._previousOperation = next._previousOperation;
                    timesValue._nextOperation = next._nextOperation._nextValue?._nextOperation;

                    next = timesValue;
                    if(timesValue._previousOperation == null)
                        firstValue = timesValue;
                    break;
                }
                case OperationType.DividedBy:
                {
                    Values dividedByValue = new Values(next?._previousOperation, next._value);
                    dividedByValue._value = next._value /  next._nextOperation._nextValue._value;
                    dividedByValue._previousOperation = next._previousOperation;
                    dividedByValue._nextOperation = next._nextOperation._nextValue?._nextOperation;

                    next = dividedByValue;
                    if(dividedByValue._previousOperation == null)
                        firstValue = dividedByValue;
                    break;
                }
                default:{
                    next = next._nextOperation._nextValue;
                    break;
                }
            }
        }

        // Console.WriteLine($"After Times and DividedBy Operations");
        // next = firstValue;
        // while(next!=null){
        //     Console.WriteLine($"Value: {next._value} Operation: {next?._nextOperation?._operationType.ToString() ?? ""}");
        //     next = next?._nextOperation?._nextValue;
        // }

        result = firstValue._value;
        next = firstValue;
        while(next._nextOperation!=null && next._nextOperation._nextValue!=null){
            switch(next._nextOperation._operationType){
                case OperationType.Plus:
                {
                    result+= next._nextOperation._nextValue._value;
                    break;
                }
                case OperationType.Minus:
                {
                    result-= next._nextOperation._nextValue._value;
                    break;
                }
            }
            next = next._nextOperation._nextValue;
        }
        return result;
    }

}