import { ChangeEvent, useState } from "react"
import { appsettings } from "../settings/appsettings"
import { useNavigate } from "react-router-dom"
import Swal from "sweetalert2"
import { ICliente } from "../Interfaces/IClientes"
import { Container,Row, Col, Form, FormGroup, Label, Input, Button } from "reactstrap"

export function NuevoCliente(){
    return(
        <h1>Componente nuevo Cliente</h1>
    )
}