const { getConnection } = require("./connection")

function getListaPersone() {
    const connection = await getConnection();
    const [lista_persone] = await connection.query("SELECT * FROM Persona");
    console.log(lista_persone);
    res.json(lista_persone).send();
};

function insertPersona() {
    const connection = await getConnection();
    await connection.query("INSERT INTO persona (nome, cognome, codice_fiscale) VALUES (?, ?, ?);", [req.body.nome, req.body.cognome, req.body.codice_fiscale]);
    console.log("ok");
    res.json("ok").send();
}

function deletePersona() {
    const connection = await getConnection();
    await connection.query("DELETE FROM persona WHERE id = ?", [req.body.elimina]);
    console.log("ok");
    res.json("ok").send();
}

module.exports = {
    getListaPersone,
    insertPersona,
    deletePersona
}