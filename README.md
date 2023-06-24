The intention of this project is to read in JSON files from the Cricsheet dataset
and create a flattened version of the data, with some normalisation, to allow for
easier analysis of the data.

## Usage

```
parse-cricsheet <zip> <output> [options]
```

### Arguments

* `zip` - The path to the zip file containing the JSON files to parse. Should use the
JSON format of the downloads available [here](https://cricsheet.org/downloads/).
* `output` - The path to the SQLite database to create.

### Options

* `--register` - Path to people.csv. Available [here](https://cricsheet.org/register/).