const Article = require('../models').Article;

module.exports = {
    createGet: (req, res) => {
        res.render('article/create')
    },

    createPost: (req, res) => {
        let articleArgs = req.body;

        let errorMsg = "";

        if (!req.isAuthenticated()) {
            errorMsg = 'You should be logged in to make articles!';
        } else if (!articleArgs.title) {
            errorMsg = 'Invalid title!';
        } else if (!articleArgs.content) {
            errorMsg = 'Invalid content!';
        }

        if (errorMsg) {
           return res.render('article/create', {
               error: errorMsg
           })
        }
        articleArgs.authorId = req.user.id;

        Article.create(articleArgs).then(article => {
            res.redirect('/');
        }).catch(err => {
            res.render('article/create', {error: err.message})
        })
    },

    details: (req, res) => {
        let id = req.params.id;
        Article.findById(id)
            .then(article => {
                res.render('article/details', article.dataValues);
            })
    }
};