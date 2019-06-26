var rockets = [
    { ID: 0, Builder: "NASA", Target: "Moon", Speed: 7.8 },
    { ID: 1, Builder: "NASA", Target: "Mars", Speed: 10.9 },
    { ID: 2, Builder: "NASA", Target: "Kepler-452b", Speed: 42.1 },
    { ID: 3, Builder: "NASA", Target: "N/A", Speed: 0.0 }];


//Serialisation
var jsonString = JSON.stringify(rockets);
document.write(jsonString);
document.write('<br/>');

document.write("========================");
document.write('<br/>');

//Deserisation
var objects = JSON.parse(jsonString);
for (let i in objects) {
    document.write("ID:" + objects[i].ID + " Builder:" + objects[i].Builder + " Target:" + objects[i].Target + " Speed:" + objects[i].Speed);
    document.write('<br/>');
}