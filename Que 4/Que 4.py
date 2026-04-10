#sends HTTP requests to get the webpage content, then uses BeautifulSoup toparse the HTML and extract the data.csv module is used to store a csv file.
import requests
from bs4 import BeautifulSoup
import csv

url = " https://books.toscrape.com/catalogue/category/books/travel_2/index.html"
response = requests.get(url)    #sends a request to the website and gets the response.

soup = BeautifulSoup(response.text, 'html.parser')  #parses the HTML content of the webpage

#Storing the book in a HTML block ARTICLE with class "product_pod" as an identifier.
books = soup.find_all("article", class_="product_pod")   

#Open the csv file  and write the header row to the csv file. 
with open("books.csv", "w", newline='', encoding='utf-8') as file:
    writer = csv.writer(file)
    
    writer.writerow(['Title', 'Price', 'Rating'])

#Extracting data from each book like price, title and rating and then writing it to the new csv file.
    for book in books:
        title = book.h3.a["title"]
        price = book.find("p", class_="price_color").text
        rating = book.find("p", class_="star-rating")["class"][1]
        writer.writerow([title, rating, price])

#Read the csv file and print the content.
print("\nData has been successfully written to the CSV file: \n")

with open("books.csv", "r", encoding='utf-8') as file:
    reader = csv.reader(file)
    
    for row in reader:
        print(row)

