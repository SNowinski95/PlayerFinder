import { Button } from "@mui/material";

interface SimpleProfilePorps{
    login:string,
    updateUser: any
}
const SimpleProfile: React.FC<SimpleProfilePorps> = ({ login, updateUser }) => {
  function logout()
  {
    updateUser(null);
  }
    return (
      <><p>U are log in {login}</p>
      <Button variant={"contained"} onClick={logout}>
        Logout
      </Button></>
    );
  }
  
  export default SimpleProfile;