import React, {useEffect, useState} from 'react';
import './App.css';
import axios from "axios";
import {Header, List} from "semantic-ui-react";

function App() {
    // useState activities is a variable for storing state
    // useState setActivities is a function for setting the state
    // initialState [] = empty array
    const [activities, setActivities] = useState([]);

    // useEffect function (arrow function with empty opening brackets for no parameters)
    useEffect(() => {
        // get json and then
        axios.get('http://localhost:5000/api/activities').then(response => {
            console.log(response);
            // pass response to setActivities, setActivities passes the data from response to activities variable
            setActivities(response.data);
        })
        // , after curly bracket and then empty array to ensure this runs once
    }, [])


    return (
        <div>
            <Header as="h2" icon="users" content="Reactivities"/>
            <List>
                {activities.map((activity: any) => (
                    <List.Item key={activity.id}>
                        {activity.title}
                    </List.Item>
                ))}
            </List>
        </div>
    );
}

export default App;
