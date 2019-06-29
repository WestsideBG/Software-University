package com.softuni.entity;

public class Calculator {

        private double leftOperand;
        private double rightOperand;
        private String operator;

    public Calculator(double leftOperand, double rightOperand, String operator) {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operator = operator;
    }

    public double getLeftOperand() {
        return leftOperand;
    }

    public void setLeftOperand(double leftOperand) {
        this.leftOperand = leftOperand;
    }

    public double getRightOperand() {
        return rightOperand;
    }

    public void setRightOperand(double rightOperand) {
        this.rightOperand = rightOperand;
    }

    public String getOperator() {
        return operator;
    }

    public void setOperator(String operator) {
        this.operator = operator;
    }

    public double calculateResult()
    {
        double leftOperand = this.getLeftOperand();
        double rightOperand = this.getRightOperand();
        String operator = this.getOperator();
        double result = 0.0;

        if (operator.equals("+"))
        {
            result = leftOperand + rightOperand;
        }
        else if (operator.equals("-"))
        {
            result = leftOperand - rightOperand;
        }
        else if (operator.equals("*"))
        {
            result = leftOperand * rightOperand;
        }
        else if (operator.equals("/"))
        {
            result = leftOperand / rightOperand;
        }
        else if (operator.equals("^"))
        {
            result = Math.pow(leftOperand,rightOperand);
        }
        else if (operator.equals("%"))
        {
            result = leftOperand % rightOperand;
        }

        return result;
    }
}
