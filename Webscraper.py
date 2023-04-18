
import csv
import requests
from bs4 import BeautifulSoup

# Make a GET request to the IMDB website for movies released in 2021
url = "https://www.imdb.com/search/title/?release_date=2021&sort=num_votes,desc&page=1"
response = requests.get(url)

# Parse the HTML content using BeautifulSoup
soup = BeautifulSoup(response.content, "html.parser")

# Find all the movie titles, release dates, starring cast, rating, duration, and budget on the page
movies = soup.find_all("div", class_="lister-item-content")
movies_list = []

# Extract the movie data and store them in a list
for movie in movies:
    title = movie.find("a").text
    release_date = movie.find("span", class_="lister-item-year").text.strip("()")  # strip parentheses from release year
    #stars = [star.text for star in movie.select('span.title', class_="lister-item-index")]
    rating = movie.find("strong").text
    duration = movie.find("span", class_="runtime").text.strip(" min")
    budget = movie.select(".text-muted")[1].text.strip("$") if len(movie.select(".text-muted")) > 1 else "N/A"

    # Append the movie data to the list
    movies_list.append([title, release_date, ", ".join(stars), rating, duration, budget])

# Export the movie list to a CSV file
with open("movies_2021.csv", "w", newline="", encoding="utf-8") as file:
    writer = csv.writer(file)
    writer.writerow(["Title", "Release Date", "Starring Cast", "Rating", "Duration", "Budget"])
    writer.writerows(movies_list)

print("CSV file successfully created!")
