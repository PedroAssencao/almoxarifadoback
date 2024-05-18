import { useState, useEffect } from 'react'
import './App.css'

function App() {

  const [Dados, SetDados] = useState([])

  useEffect(() => {
    fetch("https://localhost:7062/Grupo")
      .then(response => response.json())
      .then(data => SetDados(data))
  }, [])

  const costPost = (async () => {
    
    const rawResponse = await fetch('https://localhost:7062/Grupo', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ a: 1, b: 'Textual content' })
    });
  })();


  return (
    <div className='App'>
      <div id='teste'>

        <table className="table">
          <thead>
            <tr>
              <th scope="col">Codigo</th>
              <th scope="col">Nome</th>
              <th scope="col">Sugestão</th>
              <th scope="col">Opções</th>
            </tr>
          </thead>
          <tbody>
            {Dados.map((Element, index) =>
              <tr key={index}>
                <th scope="row">{Element.iD_GRU}</th>
                <td>{Element.nomE_GRU}</td>
                <td>{Element.sugestaO_GRU}</td>
                <td><button>Update</button></td>
                <td><button>Delete</button></td>
              </tr>
            )}
          </tbody>
        </table>


      </div>
    </div>
  )
}

export default App
