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

Initializetion();

function Initializetion() {
    const tempData = document.getElementsByClassName('noteId');
    if (tempData != null || tempData.length <= 0) {
        rowCount = tempData.length;
        lastNoteNumber = tempData[tempData.length - 1].value;
        let textNotes = document.querySelectorAll('.noteText');
        for (let i = 0; i < textNotes.length; i++)
            textNotes[i].addEventListener("input", OnInput, false);
    }
}

function TryCreateTable() {
    if (tableWasCreated) {
        alert('Таблица уже создана');
        return;
    }

    table = document.createElement("table");
    table.className = "tableNotes";
    table.id = "tableNotes";
    document.body.appendChild(table);

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
    td.setAttribute("style", "border-bottom: solid 1px #C4C4C4;");
    td.textContent = ++rowCount;
    td.className = "numberCell mainCell";

    td = tr.insertCell();
    td.className = "mainCell";

    let formItem = document.createElement("input")
    td.appendChild(formItem);
    formItem.value = ++lastNoteNumber
    SetAttributes(formItem, "Id", rowCount - 1);
    formItem.disabled = true;

    td = tr.insertCell();
    td.className = "mainCell";

    formItem = document.createElement("input")
    td.appendChild(formItem);
    formItem.value = new Date().toLocaleDateString();
    SetAttributes(formItem, "Date", rowCount-1);
    formItem.disabled = true;

    td = tr.insertCell();
    let inputbox = document.createElement("textarea");
    inputbox.setAttribute("placeholder", "Type, paste, cut text here...");
    inputbox.addEventListener("input", OnInput, false);
    SetAttributes(inputbox, "NoteText", rowCount-1);
    inputbox.className = "noteText";
    td.appendChild(inputbox);
}

function SetAttributes(formItem, formItemType, index) {
    formItem.setAttribute("id", "Notes_" + index + "__" + formItemType);
    formItem.setAttribute("name", "Notes[" + index + "]." + formItemType);
    formItem.className = "note" + formItemType;
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

    UpdateCells(index);

    if (rowCount < 1)
        DropTable();
}

function UpdateCells(startIndex) {
    let indexCells = document.querySelectorAll('.numberCell');
    // Нужно перенести эти обновления на момент сохранения таблицы
    let idCells = document.querySelectorAll('.noteId');
    let dateCells = document.querySelectorAll('.noteDate');
    let textCells = document.querySelectorAll('.noteText');

    for (let i = startIndex - 1; i < indexCells.length; i++) {
        indexCells[i].textContent = i+1;
        SetAttributes(idCells[i], "Id", i);
        SetAttributes(dateCells[i], "Date", i);
        SetAttributes(textCells[i], "NoteText", i);
        textCells.className = "noteText";
    }
}


function DropTable() {
    tableWasCreated = false;
    addRowButton.disabled = true;
    removeRowButton.disabled = true;
    createTableButton.disabled = false;
    table.remove();
}

function OnInput() {
    this.style.height = 'auto';
    this.style.height = (this.scrollHeight) + "px";
}

