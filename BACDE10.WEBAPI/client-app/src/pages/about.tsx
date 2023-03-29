import { useEffect, useState } from 'react';
interface Item {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  city: string;
}
export default function About() {
  const [items, setItems] = useState<Item>({
    id: 0,
    firstName: '',
    lastName: '',
    address: '',
    city: '',
  });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await fetch('https://localhost:44339/api/Client');
        const data = await response.json();
        setItems(data);
        setLoading(false);
      } catch (error) {
        console.error(error);
      }
    }

    fetchData();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h2>{items.lastName}</h2>
      <p>{items.firstName}</p>
      <p>{items.address}</p>
      <p>{items.city}</p>
    </div>
  );
}
