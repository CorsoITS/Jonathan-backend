const mysql2 = require("mysql2/promise")
require('dotenv').config()

let connection;
async function getConnection () {
    if (!connection) {
        connection = await mysql2.createConnection({
            host: "localhost",
            user: "root",
            password: process.env.YOUR_PASSWORD,
            database: "piattaforma_vaccini_v2"
        });
    }
    return connection;
}

module.exports = {
    getConnection
};