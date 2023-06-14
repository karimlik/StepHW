fetch('data.json')
    .then(response => response.json())
    .then(data => {
        const tableBody = document.querySelector(`#dataTable tbody`);

        populateTable(data);

        const searchBar = document.querySelector(`#searchInput`);
        searchInput.addEventListener('input', () => {
            const searchTerm = searchInput.value.toLowerCase();
            const filteredData = data.filter(item => {
              return item.name.toLowerCase().includes(searchTerm) ||
                item.city.toLowerCase().includes(searchTerm);
            });
            populateTable(filteredData);
          });
      

        function populateTable(data) {

            tableBody.innerHTML = ``;

            data.forEach(item => {
                const row = document.createElement(`tr`);

                const NameCell = document.createElement(`td`);
                NameCell.textContent = item.name;
                row.appendChild(NameCell);

                const AgeCell = document.createElement(`td`);
                AgeCell.textContent = item.age;
                row.appendChild(AgeCell);

                const CityCell = document.createElement(`td`);
                CityCell.textContent = item.city;
                row.appendChild(CityCell);

                tableBody.appendChild(row);
            });
        }


    })
    .catch(error => {
        console.error('Error:', error);
    });