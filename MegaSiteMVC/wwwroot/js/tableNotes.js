let tableWasCreated = false;
let rowCount = 0;
let lastNoteNumber = 0;
let table;

const createTableButton = document.getElementById('createTableButton');
const addRowButton = document.getElementById('addRowButton');
const removeRowButton = document.getElementById('removeRowButton');
const lineIndex = document.getElementById('lineIndex');
createTableButton.disabled = false;
addRowButton.disabled = true;
removeRowButton.disabled = true;

function TryCreateTable()
{
    if(tableWasCreated)
    {
        alert('Таблица уже создана');
        return;
    }

    table = document.createElement("table");
    table.className = "tableNotes";
    table.id = "tableNotes";
    document.body.appendChild(table);
    table.style.border = '1px solid black';

    table.innerHTML = `<thead class="thead-dark">
    <tr>
      <th scope="col">№</th>
      <th scope="col">Date</th>
      <th scope="col" style="width:90%">Note</th>
    </tr>
  </thead>`;

  AddRow();


    tableWasCreated = true;
    addRowButton.disabled = false;
    removeRowButton.disabled = false;

    rowCount = 1;

    const tableContainer = document.getElementById('tableContainer');
    if (tableContainer == null)
        console.log("Error!");
    tableContainer.appendChild(table);
}

function AddRow()
{
    const tr = table.insertRow();
    let td = tr.insertCell();
    td.style.border = '1px solid black';
    rowCount++;
    td.textContent = ++lastNoteNumber;
    td.className = "numberCell";

    td = tr.insertCell();
    td.style.border = '1px solid black';
    td.textContent = new Date().toLocaleDateString();

    td = tr.insertCell();
    td.style.border = '1px solid black';
    let inputbox = document.createElement("textarea");
    inputbox.className = "noteArea";
    inputbox.setAttribute("placeholder", "Type, paste, cut text here...");
    inputbox.addEventListener("input", OnInput, false);
    td.appendChild(inputbox);
}

function RemoveRow()
{
    let index = lineIndex.value;

    if(isNaN(index))
    {
        alert("NaN");
        return;
    }

    if(index.trim() === '')
    {
        table.deleteRow(rowCount--);
        if(rowCount === 0)
            DropTable();
        return;
    }

    if(index > rowCount || index < 1)
    {
        alert("Line not found");
        return;
    }

    table.deleteRow(index);
    rowCount--;

    // Если первый столбик отвечает за порядковый номер, то обновляет числа
    /*UpdateCells(index);*/

    if(rowCount < 1)
        DropTable();
}

function UpdateCells(startIndex)
{
    let cells = document.querySelectorAll('.numberCell');
    let i = startIndex;
    cells.forEach(element => {
        element.textContent = ++i;
    });
}


function DropTable()
{
    tableWasCreated = false;
    addRowButton.disabled = true;
    removeRowButton.disabled = true;

    table.remove();
}

function OnInput() {
    this.style.height = 'auto';
    this.style.height = (this.scrollHeight) + "px";
  }

