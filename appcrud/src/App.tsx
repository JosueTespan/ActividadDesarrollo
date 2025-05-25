import { BrowserRouter, Route, Routes } from "react-router-dom"
import { EditarCliente } from "./components/EditarCliente"
import { NuevoCliente } from "./components/NuevoCliente" 
import { ListaCliente } from "./components/ListaCliente"
import { ListaMoto } from "./components/ListaMoto"
import { NuevaMoto } from "./components/NuevoMoto"
import { NuevoServicioCliente } from "./components/NuevoServicioCliente"

function App() {

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<ListaCliente />} />
        <Route path="/editarcliente/:id" element={<EditarCliente />} />
        <Route path="/nuevocliente" element={<NuevoCliente />} />
        <Route path="/listamoto" element={<ListaMoto />} />
        <Route path="/nuevamoto/:idCliente" element={<NuevaMoto />} />
        <Route path="/nuevoservicio/:idCliente" element={<NuevoServicioCliente />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
