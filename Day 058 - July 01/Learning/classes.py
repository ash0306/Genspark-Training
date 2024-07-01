# 1) Python class

class Books:
    genre = []
    def __init__(self,name):
        self.name = name

    def add_genre(self,new_genre):
        self.genre.append(new_genre)
    
    def display_details(self):
        print(f"Book Name: {self.name}")
        print("Genres:")
        for genre in self.genre:
            print(genre)

print(f'{'Books Base class':*^30}')
book1 = Books('Shatter Me')
book1.add_genre("Fantasy")
book1.display_details()


# 2) Inheritance in python

class EBook(Books):
    file_size = 0
    def __init__(self, name, format_type):
        super().__init__(name)
        self.format_type = format_type 
    
    def add_file_size(self, file_size):
        self.file_size = file_size

    def display_details(self):
        super().display_details()
        print(f"File Size: {self.file_size} MB")
        print(f"Format: {self.format_type}")


print(f'{'EBook Subclass':*^30}')
ebook1 = EBook('Percy Jackson', 'EPUB')
ebook1.add_file_size(1.5)
ebook1.add_genre("Action")
ebook1.add_genre("Fantasy")
ebook1.display_details()


# 3) Polymorphism in python

print(f'{'Polymorphism':*^30}')
def book_details(book_obj):
    book_obj.display_details()

book_details(book1)
book_details(ebook1)