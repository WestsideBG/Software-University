<?php

namespace SoftUniBlogBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use SoftUniBlogBundle\Entity\Article;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;

class HomeController extends Controller
{

    /**
     * @Route("/", name="blog_index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index()
    {
        $repository = $this
            ->getDoctrine()
            ->getRepository(Article::class);

        $articles = $repository->findAll();
        return $this->render('home/index.html.twig',
            [
                "articles" => $articles
            ]);


    }
}
