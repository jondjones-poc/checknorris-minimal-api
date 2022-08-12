# ChuckNorrisApi - By Jon D Jones 💥

This project makes use of:

- ASP.NET 6
- Minimal API 
- [Api.chucknorris](https://api.chucknorris.io/)

## 👻 Live Site URL & Status 👺

[https://chucknorrisapi.azurewebsites.net/joke/chuck](https://chucknorrisapi.azurewebsites.net/joke/chuck)

## 👾 How To Use ☄️

The API contains three end-points

[/joke/{topic?}](https://localhost:7288/joke/chuck)

GET Request:  Get a list of Chuck Norris jokes based on a topic.  Add a topic to the end of the URL get results

[/jokebycategory/{category}](https://localhost:7288/jokebycategory/chuck)

POST Request:  Get a list of Chuck Norris jokes based on a category.  Add the category to the end of the URL get results

[/random](https://localhost:7288/random)

PUT Request:  Returns a random Chuck Norris joke


You can see the end-points using swagger:

[/swagger/index.html](https://localhost:7288/swagger/index.html)
