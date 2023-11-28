using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;
    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articleData = 
            {
            "Article Content Author",
            "Article2 Content2 Author2",
            "Article3 Content3 Author3"
            };
        // Act
        Article result = _article.AddArticles(articleData);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Stan",
                    Content = "Some Content",
                    Title = "Coding",
                },
                new Article()
                {
                    Author = "Markov",
                    Content = "Big",
                    Title = "Smoll"
                }

            }
        };
        string expected = $"Coding - Some Content: Stan{Environment.NewLine}Smoll - Big: Markov";
        // Act
        string actual = this._article.GetArticleList(inputArticle, "title");

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Stan",
                    Content = "Some Content",
                    Title = "Coding",
                },
                new Article()
                {
                    Author = "Markov",
                    Content = "Big",
                    Title = "Smoll"
                }

            }
        };
        string expected = $"Coding - Some Content: Stan{Environment.NewLine}Smoll - Big: Markov";
        // Act
        string actual = this._article.GetArticleList(inputArticle, "noo");

        // Assert
        Assert.AreEqual(string.Empty, actual);
    }
}
