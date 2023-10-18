import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Hello!</h1>
                <p>This project was created by Mikhail Prokopenko.</p>
                <p>The project was developed using <code>ASP.Net</code> & <code>React</code>. <code>SQL Server</code> is used as storage. <code>Entity Framework</code> is used to work with the database.</p>
                <p>You can add data to a table using the <code>URL/dataprocess</code> method.</p>
                <p>You can see all methods by the <code>URL/swagger</code>.</p>
                <p>When you first run a project, you must first run the <code>FillTableProject</code>. It will create a database and populate it with the contents of the <code>interview.X.cs</code> and <code>interview.Y.cs</code> files.</p>

            </div>
        );
    }
}
