class Calculator {
    constructor(leftOperand, rightOperand, operator){
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operator = operator;
    }
    calculate() {
        switch (this.operator){
            case '+':
                return this.leftOperand + this.rightOperand;
                break;
            case '-':
                return this.leftOperand - this.rightOperand;
                break;
            case '*':
                return this.leftOperand * this.rightOperand;
                break;
            case '/':
                return this.leftOperand / this.rightOperand;
                break;
        }
    }
}

module.exports = Calculator;