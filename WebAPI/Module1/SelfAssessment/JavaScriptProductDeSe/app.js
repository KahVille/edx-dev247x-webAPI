let p1 = {id:101, name:'Product-101', price: 99};


//task2 Serliaze and Desrialize given object
let jsonString = JSON.stringify(p1);
document.write('<br/>');
document.write('<h3> Seriliazed javascript object details p1</h3>')
document.write('JSON: '+ jsonString);
document.write('<br/>');

document.write('<h3> JavaScript Deseriliazed object details p1 </h3>')

let productDataObject = JSON.parse(jsonString);
const entriesJavsScript = Object.entries(productDataObject)
PrintObjectDetails(entriesJavsScript);



//task3 Serliaze string copied from c# output
//{"ID":3,"Name":"Tea","Price":2.5}

let jsonCSharpString =  JSON.stringify({"ID":3,"Name":"Tea","Price":2.5});

document.write('<h3> Javascript seriliazed c# object details with its properties </h3>')
document.write('JSON:');
document.write(jsonCSharpString);
document.write('<br/>');

let objectFromCSharp = JSON.parse(jsonCSharpString);
const entriescSharp = Object.entries(objectFromCSharp)
PrintObjectDetails(entriescSharp);

document.write('<h3> JavaScript seriliazed c# object details with keys as defined in original javascript object p1</h3>');
PrintcSharpObjectDetailsAsJavaScriptObject(objectFromCSharp);
document.write('<h3> This proves that in order to serialize c# object into Javascript object, or other way around, property names must match each other</h3>');

//helper functions
function PrintcSharpObjectDetailsAsJavaScriptObject(productToPrint) {
        document.write(productToPrint.id);
        document.write(productToPrint.name);
        document.write(productToPrint.price); 
}

function PrintObjectDetails(entriesToPrint) {
        for (const [key, value] of entriesToPrint) {
                document.write(` ${key} : ${value} <br/> `);
        } 
}