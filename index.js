const express = require("express")
const { getConnection } = require("./connection")
const app = express()

app.get("/", async (res, req) => {
    const connection = await getConnection();
    const [lista_persone] = await connection.query("SELECT * FROM Persona");
    console.log(lista_persone);
    req.json(lista_persone).send();
});

//app.post("/", (res, req) => {
//    const connection = await getConnection();
//    await connection.query("INSERT INTO Persona VALUES (2, Pippo, Moriarti, PIPMOR231");
//})


app.listen(3000)