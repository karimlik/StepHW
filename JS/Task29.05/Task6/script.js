function highlightBook(bookElement) {
  const bookList = document.getElementsByClassName('book-list')[0];
  const highlightedBook = bookList.getElementsByClassName('highlight')[0];
  
  if (highlightedBook) {
    highlightedBook.classList.remove('highlight');
  }
  
  bookElement.classList.add('highlight');
}