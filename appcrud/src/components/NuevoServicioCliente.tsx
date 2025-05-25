import { useState, useEffect, type FormEvent, type ChangeEvent } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Swal from "sweetalert2";
import { Container, Row, Col, Form, FormGroup, Label, Input, Button } from "reactstrap";
import { appsettings } from "../settings/appsettings";
import type { ICliente } from "../Interfaces/IClientes";
import type { IServicio } from "../Interfaces/IServicio";
import type { IServicioCliente } from "../Interfaces/IServicioCliente";

export function NuevoServicioCliente() {
  const navigate = useNavigate();
  const { idCliente } = useParams();
  const clienteId = Number(idCliente);

  const [cliente, setCliente] = useState<ICliente | null>(null);
  const [servicio, setServicio] = useState<IServicio>({
    idServicio: 0,
    nombreServicio: "",
    precio: 0,
  });

  useEffect(() => {
    const obtenerCliente = async () => {
      try {
        if (!clienteId) return;
        const res = await fetch(`${appsettings.apiUrl}Cliente/Obtener/${clienteId}`);
        if (!res.ok) throw new Error("Cliente no encontrado");
        const data = await res.json();
        setCliente(data);
      } catch (error) {
        console.error(error);
        Swal.fire("Error", "No se pudo cargar el cliente", "error");
      }
    };

    obtenerCliente();
  }, [clienteId]);

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setServicio((prev) => ({
      ...prev,
      [name]: name === "precio" ? Number(value) : value,
    }));
  };

  const guardarServicio = async (e: FormEvent) => {
    e.preventDefault();

    try {
      if (!servicio.nombreServicio || servicio.precio! <= 0 || !clienteId) {
        Swal.fire("Campos incompletos", "Ingrese nombre del servicio y precio válidos", "warning");
        return;
      }

      // Registrar el nuevo servicio
      const resServicio = await fetch(`${appsettings.apiUrl}Servicio/Nuevo`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${localStorage.getItem("token") || ""}`,
        },
        body: JSON.stringify(servicio),
      });

      if (!resServicio.ok) {
        const err = await resServicio.json();
        throw new Error(err.mensaje || "Error al registrar el servicio");
      }

      const servicioCreado: IServicio = await resServicio.json();

      // Registrar el servicio para el cliente
      const servicioCliente: IServicioCliente = {
        idCliente: clienteId,
        idServicio: servicioCreado.idServicio,
      };

      const resSC = await fetch(`${appsettings.apiUrl}ServicioCliente/Registrar`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${localStorage.getItem("token") || ""}`,
        },
        body: JSON.stringify(servicioCliente),
      });

      if (!resSC.ok) {
        const err = await resSC.json();
        throw new Error(err.mensaje || "Error al asignar el servicio al cliente");
      }

      await Swal.fire("Éxito", "Servicio registrado y asignado correctamente", "success");
      navigate("/listaserviciocliente");
    } catch (error) {
      console.error(error);
      Swal.fire("Error", error instanceof Error ? error.message : "Error general", "error");
    }
  };

  const volver = () => {
    navigate(-1);
  };

  return (
    <Container className="mt-5">
      <Row>
        <Col sm={{ size: 8, offset: 2 }}>
          <h4>Nuevo Servicio para Cliente</h4>
          <hr />
          {cliente && (
            <div className="mb-3">
              <strong>Cliente:</strong> {cliente.nombreCompleto} <br />
              <strong>Teléfono:</strong> {cliente.telefono} <br />
              <strong>Correo:</strong> {cliente.correo}
            </div>
          )}

          <Form onSubmit={guardarServicio}>
            <FormGroup>
              <Label for="nombreServicio">Nombre del Servicio</Label>
              <Input
                type="text"
                name="nombreServicio"
                id="nombreServicio"
                value={servicio.nombreServicio}
                onChange={handleChange}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label for="precio">Precio</Label>
              <Input
                type="number"
                name="precio"
                id="precio"
                value={servicio.precio}
                onChange={handleChange}
                required
                min="0"
              />
            </FormGroup>

            <div className="mt-4">
              <Button color="primary" type="submit" className="me-3">
                Guardar
              </Button>
              <Button color="secondary" onClick={volver}>
                Volver
              </Button>
            </div>
          </Form>
        </Col>
      </Row>
    </Container>
  );
}
