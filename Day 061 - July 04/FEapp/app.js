const express = require("express");
const app = express();
const port = 3231;

app.get("/", (req, res) => {
  res.send("Hello World!!");
});

app.listen(port, () => {
  console.log(`Check change app listening at http://localhost:${port}`);
});
