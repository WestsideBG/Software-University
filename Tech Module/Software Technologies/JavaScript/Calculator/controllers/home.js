const Calculator = require('../models/Calculator');
module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },

    indexPost: (req, res) => {

        let input = req.body['calculator'];

        let operator = input.operator;
        let leftOperand = Number(input.leftOperand);
        let rightOperand = Number(input.rightOperand);

        let calculator = new Calculator(leftOperand,rightOperand,operator);

        let result = calculator.calculate();

        res.render('home/index', {calculator: calculator, result: result});
    }

};