import requests
from bs4 import BeautifulSoup
import csv

#url = "https://www.imdb.com/search/title/?year=2021&title_type=feature&"
url = "https://www.imdb.com/search/title/?title_type=feature&year=2021-01-01,2021-12-31&ref_=adv_prv"

response = requests.get(url)
soup = BeautifulSoup(response.text, 'html.parser')

# Find all the movie containers on the page
movies = soup.find_all('div', {'class': 'lister-item mode-advanced'})

# Open a CSV file to write the data
with open('movies.csv', mode='w', newline='') as csv_file:
    fieldnames = ['Title', 'Release Date', 'Director', 'Starring Cast', 'Rating', 'Duration', 'Genre', 'Gross']
    writer = csv.DictWriter(csv_file, fieldnames=fieldnames)

    writer.writeheader()  # Write the header row

    # Loop through each movie container and extract the desired data
    for movie in movies:
        title = movie.h3.a.text.strip()
        release_date = movie.find('span', {'class': 'lister-item-year'}).text.strip('()')
        director = movie.find('p', {'class': ''}).a.text
        try:
            cast_list = movie.find('p', class_='').find_all('a')[1:]
            cast = [actor.text.strip() for actor in cast_list]
        except AttributeError:
            cast = None
        rating = movie.find('div', {'class': 'inline-block ratings-imdb-rating'})['data-value']
        duration = movie.find('span', {'class': 'runtime'}).text.strip(' min')
        genre = movie.find('span', {'class': 'genre'}).text.strip()
        try:
            gross = movie.find('span', {'name': 'nv'}).find_next().find_next().find_next().string
        except AttributeError:
            gross = 'N/A'

        # Write the data to the CSV file
        writer.writerow({'Title': title, 'Release Date': release_date, 'Director': director,
                         'Starring Cast': ', '.join(cast), 'Rating': rating, 'Duration': duration,
                         'Genre': genre, 'Gross': gross})
