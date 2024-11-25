# Hotel Data Merger CLI

## Overview
This project is a Command Line Interface (CLI) application designed to merge hotel data from multiple suppliers into a unified structure. It allows users to filter hotels by specific `hotel_ids` and `destination_ids` and outputs the merged data in JSON format. This exercise simulates the data cleaning and integration process common in hotel websites.

## Features
- Fetches raw hotel data from multiple suppliers.
- Merges the data from different sources.
- Sanitizes and normalizes data to ensure consistency.
- Allows filtering of results based on `hotel_ids` and `destination_ids`.
- Outputs merged data in a consistent JSON format.
- Easy to extend with new suppliers and data merge strategies.

## Requirements
- C# development environment.
- .NET Core SDK.
- Internet connection to fetch supplier data.

## Installation
1. Clone the repository:
 ```bash
 git clone https://github.com/ngocanh01/HotelDataMerger.git
 cd HotelDataMerger
```
## Restore dependencies
```bash
 dotnet restore
```
## Build the project:
```bash
dotnet build
```
## Publish the app
```bash
dotnet publish -c Release -r win-x64 --self-contained
```
## Navigate to the app
```bash
cd HotelDataMerger
```
## Run the application
```bash
runner.bat "<hotel_ids>" "<destination_ids>"
```
Example:
```bash
runner.bat "iJhz,SjyX" "5432"
runner.bat "iJhz" "none"
runner.bat "none" "none"
```
### To execute the app with different arguments, modify the runner script in the root of the project.
## Program Logic

### 1. Fetch Raw Data
The application fetches hotel data from three different suppliers (Acme, Patagonia, Paperflies) via their respective APIs. Each supplier returns hotel information in slightly different formats.

### 2. Data Normalization
To ensure the data can be processed uniformly, the Adapter Pattern is used to convert data from each supplier into a common hotel data format.

### 3. Data Merging
The Strategy Pattern allows for applying different merging strategies to handle variations in the data, such as choosing which supplier's data to prioritize when there are conflicts.

### 4. Data Filtering
The application accepts two command-line arguments (`hotel_ids` and `destination_ids`). These arguments are used to filter the merged hotel data. If no IDs are provided, all hotels are returned.

### 5. Output
Once the data is merged and filtered, the application prints the final result in JSON format to the console.

## Design Patterns Used

### 1. Factory Pattern
The Factory Pattern is used to create instances of different suppliers (Acme, Patagonia, Paperflies) based on the user's input. This allows for easy extension of the program if new suppliers need to be added in the future.

**Benefit**:
- Simplifies the addition of new suppliers without modifying the core logic.
- Follows the Open/Closed Principle (OCP), as the code can be extended with new suppliers without changing existing logic.

**Drawback**:
- Adds an additional layer of abstraction, which may make the code harder to understand for beginners.

### 2. Strategy Pattern
The Strategy Pattern is used to provide different strategies for merging hotel data. The merging logic can change depending on the supplier and data format, and this pattern allows dynamic switching between these strategies.

**Benefit**:
- Makes it easy to modify or add new strategies without affecting the rest of the code.
- Follows the Open/Closed Principle (OCP), allowing the merging logic to be extended without modifying existing classes.

**Drawback**:
- The number of strategies can increase over time, which may make the code harder to maintain if not carefully organized.

### 3. Adapter Pattern
The Adapter Pattern is used to convert each supplier's data format into a standard format that the rest of the application can process uniformly.

**Benefit**:
- Ensures data consistency despite varying formats from different suppliers.
- Helps implement the Single Responsibility Principle (SRP) by isolating data transformation logic.

**Drawback**:
- Can lead to a large number of adapter classes if there are many suppliers with different data formats.

## Benefits of the Design
- **Maintainability**: The application is easy to maintain and extend due to the use of design patterns that promote separation of concerns and modularity.
- **Flexibility**: Adding new suppliers or changing data merging strategies can be done with minimal changes to the core code.
- **Scalability**: The use of patterns like the Factory and Strategy Pattern allows the code to scale if more suppliers or complex merging logic is added in the future.
