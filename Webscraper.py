import requests
from bs4 import BeautifulSoup
import csv

import csv
import requests
from bs4 import BeautifulSoup

def scrapeme(url):
    response = requests.get(url)
    soup = BeautifulSoup(response.text, 'html.parser')

    # Find all the movie containers on the page
    movies = soup.find_all('div', {'class': 'lister-item mode-advanced'})

    # Open the CSV file in append mode
    with open('movies.csv', mode='a', newline='') as csv_file:
        fieldnames = ['Title', 'Release Date', 'Director', 'Starring Cast', 'Rating', 'Duration', 'Genre', 'Gross']
        writer = csv.DictWriter(csv_file, fieldnames=fieldnames)

        # Don't write the header row if the file already exists
        if csv_file.tell() == 0:
            writer.writeheader()

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

startyear = 2002
for i in range(1,21):
    startindex = 1
    for x in range(1,5):
        starturl = "https://www.imdb.com/search/title/?title_type=feature&year="+str(startyear)+"-01-01,"+str(startyear)+"-12-31&start="+str(startindex)+"&ref_=adv_nxt"
        scrapeme(starturl)
        startindex+=50
    startyear+=1



