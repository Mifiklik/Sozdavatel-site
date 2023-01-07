let rowCount = 0;
let lastNoteNumber = 0;
let table;

table = document.getElementById('tableNotes');
let tableWasCreated = (table != null);

const createTableButton = document.getElementById('createTableButton');
const addRowButton = document.getElementById('addRowButton');
const removeRowButton = document.getElementById('removeRowButton');
const lineIndex = document.getElementById('lineIndex');

createTableButton.disabled = tableWasCreated;
addRowButton.disabled = !tableWasCreated;
removeRowButton.disabled = !tableWasCreated;

function TryCreateTable() {
    if (tableWasCreated) {
        alert('Таблица уже создана');
        return;
    }

    table = document.createElement("table");
    table.className = "tableNotes";
    table.id = "tableNotes";
    document.body.appendChild(table);
    table.style.border = '1px solid black';

    table.innerHTML = 
    `<tr>
        <th scope="col">№</th>
        <th scope="col">Id</th>
        <th scope="col">Date</th>
        <th scope="col" style="width:90%">Note</th>
    </tr>`;

    AddRow();


    tableWasCreated = true;
    addRowButton.disabled = false;
    removeRowButton.disabled = false;

    rowCount = 1;

    const tableContainer = document.getElementById('tableContainer');
    if (tableContainer == null)
        console.log("Error! Table container not found");
    tableContainer.appendChild(table);
}

function AddRow() {
    const tr = table.insertRow();
    let td = tr.insertCell();
    td.style.border = '1px solid black';
    td.textContent = ++rowCount;
    td.className = "numberCell";

    td = tr.insertCell();
    td.style.border = '1px solid black';
    td.textContent = ++lastNoteNumber;

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

function RemoveRow() {
    let index = lineIndex.value;

    if (isNaN(index)) {
        alert("NaN");
        return;
    }

    if (index.trim() === '') {
        table.deleteRow(rowCount--);
        if (rowCount === 0)
            DropTable();
        return;
    }

    if (index > rowCount || index < 1) {
        alert("Line not found");
        return;
    }

    table.deleteRow(index);
    rowCount--;

    UpdateCellsIndex(index);

    if (rowCount < 1)
        DropTable();
}

function UpdateCellsIndex(startIndex) {
    let cells = document.querySelectorAll('.numberCell');

    for (let i = startIndex; i <= cells.length; i++) {
        cells[i - 1].textContent = i;
    }
}


function DropTable() {
    tableWasCreated = false;
    addRowButton.disabled = true;
    removeRowButton.disabled = true;

    table.remove();
}

function OnInput() {
    this.style.height = 'auto';
    this.style.height = (this.scrollHeight) + "px";
}

function SaveTable() {
    let notes = new Array();

    for (let i = 1; i < table.rows.length; i++) {

        let row = table.rows[i];

        let note = {};
        note.Id = row.cells[1].innerHTML;
        note.Date = row.cells[2].innerHTML;
        note.NoteText = row.cells[3].innerHTML;

        note.push(myEmployee);

    }

    document.getElementsByName("SavedNotes")[0].value = JSON.stringify(note);
    return data;
}

