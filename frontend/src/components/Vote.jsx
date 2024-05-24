import React, { useEffect, useState } from "react";
import axios from "axios";
import config from "../config";
import {
  Button,
  Container,
  Row,
  Table,
  Col,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Label,
  Input,
} from "reactstrap";
import { IoMdAdd } from "react-icons/io";
function Vote() {

  //**** Axios Start ****// 

  const BaseURL = "https://localhost:7204";
  axios.defaults.baseURL = config.API_URL;
  // content type
  axios.defaults.headers.post["Content-Type"] = "application/json";
  //  axios.defaults.headers.post["Authorization"] = "bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyIiwidW5pcXVlX25hbWUiOiJzdHJpbmciLCJyb2xlIjoiU3VwZXJBZG1pbiIsIm5iZiI6MTcxNDEwODg4MiwiZXhwIjoxNzE0MTk1MjgyLCJpYXQiOjE3MTQxMDg4ODJ9.1AkdSkvEKbjYrM7Jb5m4RIDim6cveFXP51wKGN2SaBmAyAenaaC2T335uoUibQ3nO8HfR681aoKsinjWmu0rZg";
  axios.defaults.headers.post["Access-Control-Allow-Origin"] = "*";

  //**** Axios End ****// 

  const [modal, setModal] = useState(false);
  const [candidateList, setcandidateList] = useState([]);
  const [voterList, setVoterList] = useState([]);
  const [voteList, setVoteList] = useState([]);

  const [selectedcandidate, setSelectedcandidate] = useState({ id: 0, name: "" });
  const [selectedVoter, setselectedVoter] = useState({ id: 0, name: "" });
  const [vote, setVote] = useState({ voterId: 0, candidateId: 0 });

  const [modalCandidate, setmodalCandidate] = useState(false);
  const toggle_Voter = () => setModal(!modal);
  const toggle_candidate = () => setmodalCandidate(!modalCandidate);


  //**** API Start ****// 
  /* We can divide into seperate components for voters, candidated and results */

  const GetCandidates = async () => {
    let res = await axios.get("/candidate")
    setcandidateList(res.data.data)

  }

  const GetVoters = async () => {
    let res = await axios.get("/voter")
    setVoterList(res.data.data)

  }

  const GetVote = async () => {
    let res = await axios.get("/vote")
    setVoteList(res.data.data)
    console.table(res.data.data)    
  }

  const AddVoter = async () => {
    let res = await axios.post("/voter", selectedVoter)    
    setVoterList([...voterList, res.data.data])
    alert('Voter Added.')
    toggle_Voter()

  }

  const AddVote = async () => {

    if (!vote.voterId) {
      alert("Please Select Voter!")
      return;

    }
    if (!vote.candidateId) {
      alert("Please Select Candidate!")
      return;

    }

    let res = await axios.post("/vote", vote)    
    setVoteList([...voteList,res.data.data])
    alert(voterList.find(x => x.id == vote.voterId).name + ' Voted For ' + candidateList.find(x => x.id == vote.candidateId).name)
  }

  const AddCandidate = async () => {
    let res = await axios.post("/candidate", selectedcandidate)
    setcandidateList([...candidateList, res.data.data])
    alert('Candidate Added.')
    toggle_candidate()

  }

  //**** API End ****// 

  useEffect(() => {
    GetCandidates()
    GetVoters()
    GetVote()
  }, [])

  return (
    <section>
      <Modal isOpen={modal} toggle={toggle_Voter}>
        <ModalHeader toggle={toggle_Voter}>Add Voter</ModalHeader>
        <ModalBody>
          <Label for="exampleEmail">Voter Name</Label>
          <Input
            onChange={(e) => { setselectedVoter({ id: 0, name: e.target.value }) }}
            value={selectedVoter.name}
            placeholder="Enter Voter Name"
            type="text"
          />
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={AddVoter}>
            Submit
          </Button>{" "}
          <Button color="secondary" onClick={toggle_Voter}>
            Cancel
          </Button>
        </ModalFooter>
      </Modal>
      <Modal isOpen={modalCandidate} toggle={toggle_candidate}>
        <ModalHeader toggle={toggle_candidate}>Modal title</ModalHeader>
        <ModalBody>
          <Label for="exampleEmail">Candidate Name</Label>
          <Input
            onChange={(e) => { setSelectedcandidate({ id: 0, name: e.target.value }) }}
            value={selectedcandidate.name}
            placeholder="Enter Candidate Name"
            type="text"
          />
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={AddCandidate}>
            Submit
          </Button>{" "}
          <Button color="secondary" onClick={toggle_candidate}>
            Cancel
          </Button>
        </ModalFooter>
      </Modal>
      <Container className="mt-4">
        <Row>
          <Col className="bg-light border pt-3" md="6">
            <Table bordered>
              <thead>
                <tr>
                  <th colSpan={3}>

                    Voters
                    <span
                      style={{ float: 'right' }}
                      className="text-danger text-right"

                    >
                      <IoMdAdd className="text-danger" onClick={toggle_Voter} />

                    </span>
                  </th>
                </tr>
                <tr>
                  <th>Id</th>
                  <th>Name</th>
                  <th>Has Voted</th>
                </tr>
              </thead>
              <tbody>
                {voterList.map((item, index) => (
                  <tr key={index}>
                    <td>{item.id}</td>
                    <td>{item.name}</td>
                    <td>{voteList.some(x => x.voterId == item.id) ? "Yes" : "No"}</td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </Col>
          <Col className="bg-light border pt-3" md="6">
            <Table bordered>
              <thead>
                <tr>
                  <th colSpan={3}>
                    Candidates{" "}
                    <span
                      style={{ float: 'right' }}
                      className="text-danger text-right"

                    >

                      <IoMdAdd
                        onClick={toggle_candidate}
                      />
                    </span>

                  </th>
                </tr>
                <tr>
                  <th>Id</th>

                  <th>Name</th>
                  <th>Votes</th>
                </tr>
              </thead>
              <tbody>
                {candidateList.map((item, index) => {
                  
                  return (
                    <tr key={index}>
                      <td>{item.id}</td>
                      <td>{item.name}</td>
                      <td>{voteList.filter(x => x.candidateId == item.id).length
                      }</td>
                    </tr>
                  )
                }
                )}
              </tbody>
            </Table>
          </Col>
        </Row>

        <Row className='mt-4'>
          <Col md="5" >
            <select
              onChange={(e) => { setVote({ voterId: e.target.value, candidateId: vote.candidateId }) }}
              value={vote.voterId}
              className='form-control' >

              <option value={0}>I am</option>
              {voterList.map((item, i) => (
                <option key={item.id} value={item.id} >{item.name}</option>
              ))}
            </select>
          </Col>
          <Col md="5" >
            <select
              onChange={(e) => {                
                setVote({ voterId: vote.voterId, candidateId: e.target.value })
              }}
              value={vote.candidateId}
              className='form-control'>
              <option value={0} >I Vote for</option>
              {candidateList.map((item, i) => (
                <option key={item.id} value={item.id} >{item.name}</option>
              ))}
            </select>
          </Col>
          <Col md="2" >

            <Button onClick={e => { AddVote() }} type='button'>Submit</Button>
          </Col>
        </Row>
      </Container>
    </section>
  );
}

export default Vote;
