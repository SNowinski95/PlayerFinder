import { Link } from "react-router-dom";

function ErrorPage() {
    return (
        <h1>Page not found go to <Link to="/">Home</Link></h1>
  );
}

export default ErrorPage;