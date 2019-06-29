const Sequelize = require('sequelize');

module.exports = function (sequelize) {
   let Project = sequelize.define("Project", {
       title: {
           type: Sequelize.TEXT,
       },
       description: {
           type: Sequelize.TEXT,
       },
       budget: {
           type: Sequelize.INTEGER,
       }
   }, {
       timestamps:false
    });

    return Project;
};