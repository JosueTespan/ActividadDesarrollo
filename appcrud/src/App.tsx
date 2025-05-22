import { BrowserRouter, Route, Routes } from "react-router-dom"
import { Lista } from "./components/Lista"
import { NuevoCliente } from "./components/NuevoCliente"
import { EditarCliente } from "./components/EditarCliente"

function App() {

  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Lista/>}/>
      <Route path="/nuevoCliente" element={<NuevoCliente/>}/>
      <Route path="/editarCliente/:id" element={<EditarCliente/>}/>
      
    </Routes>
    </BrowserRouter>
  )
  
}


export default App
