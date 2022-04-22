const express = require("express")
const { getConnection } = require("./connection")
const app = express()
const bodyParser = require('body-parser')

app.use(bodyParser.json())

app.get("/", async (req, res) => {
    const connection = await getConnection();
    const [lista_persone] = await connection.query("SELECT * FROM Persona");
    console.log(lista_persone);
    res.json(lista_persone).send();
});

app.post("/", async (req, res) => {
    const connection = await getConnection();
    await connection.query("INSERT INTO persona (nome, cognome, codice_fiscale) VALUES (?, ?, ?);", [req.body.nome, req.body.cognome, req.body.codice_fiscale]);
    console.log("ok");
    res.json("ok").send();
})

app.delete("/", async (req, res) => {
    const connection = await getConnection();
    await connection.query("DELETE FROM persona WHERE id = ?", [req.body.elimina]);
    console.log("ok");
    res.json("ok").send();
})

app.listen(3000)