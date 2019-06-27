let p1 = {id:101, name:'Product-101', price: 99};

let jsonString = JSON.stringify(p1);
document.write('<br/>');
document.write('<h3> Seriliazed object details </h3>')
document.write(jsonString);
document.write('<br/>');

document.write('<h3> Deseriliazed object details </h3>')
let productDataObject = JSON.parse(jsonString);
const entries = Object.entries(productDataObject)

for (const [key, value] of entries) {
        document.write(` ${key} : ${value} <br/> `);
}