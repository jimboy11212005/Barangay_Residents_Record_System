const express = require("express");
const mysql = require("mysql2");
const jwt = require("jsonwebtoken");
const bcrypt = require("bcrypt");
const cors = require("cors");

const app = express();
app.use(express.json());
app.use(cors());

const SECRET = "yoursecretkey";

// DB Connection
const db = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "",
    database: "barangay_system"
});

// ================= AUTH =================

// REGISTER
app.post("/api/auth/register", async (req, res) => {
    const { name, email, password } = req.body;

    const hashedPassword = await bcrypt.hash(password, 10);

    db.query(
        "INSERT INTO users (name, email, password) VALUES (?, ?, ?)",
        [name, email, hashedPassword],
        (err, result) => {
            if (err) return res.status(500).send(err);
            res.send({ message: "User registered" });
        }
    );
});

// LOGIN
app.post("/api/auth/login", (req, res) => {
    const { email, password } = req.body;

    db.query(
        "SELECT * FROM users WHERE email = ?",
        [email],
        async (err, results) => {
            if (err) return res.status(500).send(err);

            if (results.length === 0) {
                return res.status(401).send("User not found");
            }

            const user = results[0];

            const valid = await bcrypt.compare(password, user.password);
            if (!valid) return res.status(401).send("Invalid password");

            const token = jwt.sign({ id: user.id }, SECRET, {
                expiresIn: "1h"
            });

            res.send({ token });
        }
    );
});

// ================= MIDDLEWARE =================

function verifyToken(req, res, next) {
    const bearer = req.headers["authorization"];

    if (!bearer) return res.sendStatus(403);

    const token = bearer.split(" ")[1];

    jwt.verify(token, SECRET, (err, decoded) => {
        if (err) return res.sendStatus(403);

        req.user = decoded;
        next();
    });
}

// ================= RESIDENTS =================

// GET RESIDENTS
app.get("/api/residents", verifyToken, (req, res) => {
    db.query("SELECT * FROM residents", (err, results) => {
        if (err) return res.status(500).send(err);
        res.send(results);
    });
});

// SEARCH RESIDENT
app.get("/api/residents/search", verifyToken, (req, res) => {
    const { name } = req.query;

    db.query(
        "SELECT * FROM residents WHERE name LIKE ?",
        [`%${name}%`],
        (err, results) => {
            if (err) return res.status(500).send(err);
            res.send(results);
        }
    );
});

app.listen(3000, () => console.log("Server running on port 3000"));