create database Insurance_management_system
-- Create Policy table
CREATE TABLE Policy (
    policyId INT PRIMARY KEY,
    policyNumber VARCHAR(50) NOT NULL,
    coverageDetails TEXT NOT NULL
);

-- Create User table
CREATE TABLE Users (
    userId INT PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL
);

-- Create Client table
CREATE TABLE Client (
    clientId INT PRIMARY KEY,
    clientName VARCHAR(255) NOT NULL,
    contactInfo VARCHAR(255) NOT NULL,
    policyId INT NOT NULL,
    FOREIGN KEY (policyId) REFERENCES Policy(policyId)
);

-- Create Claim table
CREATE TABLE Claim (
    claimId INT PRIMARY KEY,
    claimNumber VARCHAR(50) NOT NULL,
    dateFiled DATE NOT NULL,
    claimAmount DECIMAL(10, 2) NOT NULL,
    status VARCHAR(50) NOT NULL,
    policyId INT NOT NULL,
    clientId INT NOT NULL,
    FOREIGN KEY (policyId) REFERENCES Policy(policyId),
    FOREIGN KEY (clientId) REFERENCES Client(clientId)
);

-- Create Payment table
CREATE TABLE Payment (
    paymentId INT PRIMARY KEY,
    paymentDate DATE NOT NULL,
    paymentAmount DECIMAL(10, 2) NOT NULL,
    clientId INT NOT NULL,
    FOREIGN KEY (clientId) REFERENCES Client(clientId)
);



INSERT INTO users  (userId, username, password, role) values
(1, 'Pritha', 'abc', 'user'),
(2, 'kavitha', 'bcd', 'user'),
(3, 'selva', 'dce', 'user'),
(4, 'Pravin', 'lmo', 'user'),
(5, 'Dhivya', 'pqr', 'user');

INSERT INTO Policy (policyId, PolicyNumber,coverageDetails) VALUES
(1, 'POL1', 'car policy'),
(2, 'POL2', 'Home insurance policy'),
(3, 'POL3', 'Health insurance'),
(4, 'POL4', 'Travel insurance policy'),
(5, 'POL5', 'Life insurance');


INSERT INTO Client (clientId, clientName, contactInfo, policyId) VALUES
(1, 'Alice Johnson', 'alice.johnson@email.com', 1),
(2, 'Bob Smith', 'bob.smith@email.com', 2),
(3, 'Carol White', 'carol.white@email.com', 3),
(4, 'David Brown', 'david.brown@email.com', 4),
(5, 'Eva Martinez', 'eva.martinez@email.com', 5);

INSERT INTO Claim (claimId, claimNumber, dateFiled, claimAmount, status, policyId, clientId) VALUES
(1, 'CLM1001', '2024-01-10', 1500.00, 'Pending', 1, 1),
(2, 'CLM1002', '2024-01-15', 300.00, 'Approved', 2, 2),
(3, 'CLM1003', '2024-02-05', 2000.00, 'Denied', 3, 3),
(4, 'CLM1004', '2024-02-20', 750.00, 'Pending', 4, 4),
(5, 'CLM1005', '2024-03-01', 1200.00, 'Approved', 5, 5);

INSERT INTO Payment (paymentId, paymentDate, paymentAmount, clientId) VALUES
(1, '2024-01-15', 250.00, 1),
(2, '2024-02-01', 300.00, 2),
(3, '2024-02-18', 150.00, 3),
(4, '2024-03-05', 400.00, 4),
(5, '2024-03-20', 350.00, 5);