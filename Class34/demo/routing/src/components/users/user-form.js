import React from 'react';

const UserForm = props => {
  async function loadStuff(e) { 
    e.preventDefault();

    // Turn loading on
    props.toggleLoading();

    let response = await fetch('https://jsonplaceholder.typicode.com/users');
    let data = await response.json();

    console.log(data);

    let users = data.map(u => ({
      id: u.id,
      username: u.username,
      bs: u.company.bs,
    }));
    props.onReceiveUsers(users);

    // Done, turn loading off
    props.toggleLoading();
  }

  return (
    <form onSubmit={loadStuff}>
      <button>{props.prompt || 'Load'}</button>
    </form>
  )
}

export default UserForm;
